CREATE OR REPLACE FUNCTION insert_xn_mau(
    p_id_bacsi INT,
    p_id_hs INT,
    p_glucose NUMERIC,
    p_nhommau VARCHAR(3),
    p_slhongcau NUMERIC,
    p_thoigian TIMESTAMP,
    p_ghichu TEXT
)
RETURNS VOID AS $$
DECLARE
    v_id_xn INT;
BEGIN
    -- Insert vào XetNghiem và trả về ID_XN
    INSERT INTO XetNghiem (ID_HS, ID_BacSiXN, ThoiGian, GhiChu)
    VALUES (p_id_hs, p_id_bacsi, p_thoigian, p_ghichu)
    RETURNING ID_XN INTO v_id_xn;

    -- Insert vào Mau sử dụng ID_XN đã tạo
    INSERT INTO Mau (ID_XN, Glucose, NhomMau, SLHongCau)
    VALUES (v_id_xn, p_glucose, p_nhommau, p_slhongcau);
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION insert_xn_nuoctieu(
    p_id_bacsi INT,
    p_id_hs INT,
    p_glucose NUMERIC,
    p_ph NUMERIC,
    p_thoigian TIMESTAMP,
    p_ghichu TEXT
)
RETURNS VOID AS $$
DECLARE
    v_id_xn INT;
BEGIN
    -- Insert vào XetNghiem và trả về ID_XN
    INSERT INTO XetNghiem (ID_HS, ID_BacSiXN, ThoiGian, GhiChu)
    VALUES (p_id_hs, p_id_bacsi, p_thoigian, p_ghichu)
    RETURNING ID_XN INTO v_id_xn;

    -- Insert vào NuocTieu sử dụng ID_XN đã tạo
    INSERT INTO NuocTieu (ID_XN, Glucose, pH)
    VALUES (v_id_xn, p_glucose, p_ph);
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION update_hoso(
    id_hoso INT, 
    new_chandoan TEXT DEFAULT NULL, 
    new_thuoc TEXT DEFAULT NULL, 
    additional_note TEXT DEFAULT NULL
)
RETURNS VOID AS $$
BEGIN
    IF new_chandoan IS NOT NULL THEN
        UPDATE HoSoBenhAn
        SET 
            ChanDoan = array_append(ChanDoan, new_chandoan)
        WHERE 
            ID_HS = id_hoso;
    END IF;

    IF new_thuoc IS NOT NULL THEN
        UPDATE HoSoBenhAn
        SET 
            Thuoc = array_append(Thuoc, new_thuoc)
        WHERE 
            ID_HS = id_hoso;
    END IF;

    IF additional_note IS NOT NULL THEN
        UPDATE HoSoBenhAn
        SET 
            GhiChu = COALESCE(GhiChu, '') || ' ' || additional_note -- Concate xâu
        WHERE 
            ID_HS = id_hoso;
    END IF;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION insert_benhnhan(
    ho_va_ten TEXT,
    gioi_tinh CHAR(1),
    ngay_sinh DATE,
    sdt VARCHAR(11),
    id_bhyt VARCHAR(6),
    thuoc_di_ung TEXT[],
    benh_li_dac_biet TEXT[]
) RETURNS VOID AS $$
BEGIN
    INSERT INTO BenhNhan (HoVaTen, GioiTinh, NgaySinh, SDT, ID_BHYT, ThuocDiUng, BenhLiDacBiet)
    VALUES (ho_va_ten, gioi_tinh, ngay_sinh, sdt, id_bhyt, thuoc_di_ung, benh_li_dac_biet);
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION find_ketluan_by_benhnhan(p_id_benhnhan INT, p_search_text TEXT)
RETURNS TABLE (
    ID_HS INT,
    ID_BenhNhan INT,
    NgayKham DATE,
    HuyetAp INT,
    NhietDo NUMERIC,
    TinhTrangHienTai TEXT,
    ChanDoan TEXT[],
    Thuoc TEXT[],
    GhiChu TEXT,
    LanTruoc_ID_HS INT
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        h.ID_HS,
        h.ID_BenhNhan,
        h.NgayKham,
        h.HuyetAp,
        h.NhietDo,
        h.TinhTrangHienTai,
        h.ChanDoan,
        h.Thuoc,
        h.GhiChu,
        h.LanTruoc_ID_HS
    FROM HoSoBenhAn h
    WHERE h.ID_BenhNhan = p_id_benhnhan
      AND p_search_text = ANY(h.ChanDoan);
END;
$$ LANGUAGE plpgsql;