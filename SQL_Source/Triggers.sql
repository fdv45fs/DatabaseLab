-- Trigger về trùng lặp trước khi insert vào BenhNhan
CREATE OR REPLACE FUNCTION check_duplicate_benhnhan() RETURNS TRIGGER AS $$
DECLARE
    existing_benhnhan RECORD;
    force_insert BOOLEAN;
BEGIN
    -- Lấy giá trị của biến force insert
    SELECT current_setting('app.force_insert', true) INTO force_insert;
    -- Kiểm tra bản ghi trùng lặp
    SELECT * INTO existing_benhnhan
    FROM BenhNhan
    WHERE HoVaTen = NEW.HoVaTen AND NgaySinh = NEW.NgaySinh;

    IF FOUND THEN -- FOUND được set tự động nếu SELECT INTO không rỗng
        -- Nếu tìm thấy bản ghi trùng, hiển thị thông báo
        RAISE NOTICE 'Duplicate found: ID: %, Name: %, Birthdate: %, Phone: %, BHYT: %',
            existing_benhnhan.ID_BenhNhan, existing_benhnhan.HoVaTen, existing_benhnhan.NgaySinh, 
            existing_benhnhan.SDT, existing_benhnhan.ID_BHYT;

        -- Nếu force_insert là true, cho phép insert
        IF force_insert THEN
            RETURN NEW;
        ELSE
            -- Nếu force_insert là false, chặn insert
            RETURN NULL;
        END IF;
    ELSE
        -- Nếu không có bản ghi trùng, cho phép insert
        RETURN NEW;
    END IF;
END;
$$ LANGUAGE plpgsql;
CREATE TRIGGER trg_check_duplicate
BEFORE INSERT ON BenhNhan
FOR EACH ROW
EXECUTE FUNCTION check_duplicate_benhnhan();

-- Trigger về LanTruoc_ID_HS trước khi insert hoặc update
CREATE OR REPLACE FUNCTION check_LanTruoc_ID_HS() 
RETURNS TRIGGER AS $$
BEGIN
    -- Kiểm tra lần trước được thêm/sửa của cùng một bệnh nhân
    IF NEW.LanTruoc_ID_HS IS NOT NULL THEN
        IF NOT EXISTS (
            SELECT 1 
            FROM HoSoBenhAn 
            WHERE ID_HS = NEW.LanTruoc_ID_HS AND ID_BenhNhan = NEW.ID_BenhNhan
        ) THEN
            RAISE EXCEPTION 'LanTruoc_ID_HS must belong to the same patient';
        END IF;

        -- Kiểm tra một hồ sơ bệnh án không thể có lần trước là chính nó
        IF NEW.LanTruoc_ID_HS = NEW.ID_HS THEN
            RAISE EXCEPTION 'LanTruoc_ID_HS cannot be the same as ID_HS';
        END IF;
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;
CREATE TRIGGER trg_check_LanTruoc_ID_HS
BEFORE INSERT OR UPDATE ON HoSoBenhAn
FOR EACH ROW
EXECUTE FUNCTION check_LanTruoc_ID_HS();

-- Trigger kiểm tra thuốc dị ứng trước khi insert hoặc update
CREATE OR REPLACE FUNCTION check_ThuocDiUng() 
RETURNS TRIGGER AS $$
DECLARE
    listThuoc TEXT[];
    drug TEXT;
BEGIN
    -- Lấy list thuốc dị ứng
    SELECT ThuocDiUng INTO listThuoc
    FROM BenhNhan
    WHERE ID_BenhNhan = NEW.ID_BenhNhan;

    -- Duyệt từng phần tử của thuốc được kê
    IF listThuoc IS NOT NULL THEN
        FOREACH drug IN ARRAY NEW.Thuoc
        LOOP
            -- Nếu thuốc có trong list thuốc dị ứng:
            IF drug = ANY(listThuoc) THEN
                RAISE EXCEPTION 'Nguoi benh bi di ung thuoc nay: %', drug;
            END IF;
        END LOOP;
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;
CREATE TRIGGER trg_check_ThuocDiUng
BEFORE INSERT OR UPDATE ON HoSoBenhAn
FOR EACH ROW
EXECUTE FUNCTION check_ThuocDiUng();

-- Trigger về ngày khám trước khi insert vào HoSoBenhAn
CREATE OR REPLACE FUNCTION check_NgayKham() 
RETURNS TRIGGER AS $$
BEGIN
    -- Kiểm tra xem có tồn tại hồ sơ có ngày khám sau ngày khám của hồ sơ đang được insert
    IF EXISTS (
        SELECT 1 
        FROM HoSoBenhAn 
        WHERE ID_BenhNhan = NEW.ID_BenhNhan
        AND NgayKham > NEW.NgayKham
    ) THEN
        RAISE EXCEPTION 'Khong the them NgayKham moi xay ra truoc NgayKham dang co trong HoSoBenhAn';
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;
CREATE TRIGGER trg_check_NgayKham
BEFORE INSERT ON HoSoBenhAn
FOR EACH ROW
EXECUTE FUNCTION check_NgayKham();