-- Liệt kê tất cả các hồ sơ và kết quả xét nghiệm của một bệnh nhân
SELECT h.id_hs, h.id_benhnhan, h.ngaykham, h.id_bacsi, xn.*,m.glucose, m.nhommau, m.slhongcau, nt.glucose, nt.ph  

FROM hosobenhan h 

LEFT JOIN xetnghiem xn ON xn.id_hs = h.id_hs 

LEFT JOIN mau m ON m.id_xn = xn.id_xn 

LEFT JOIN nuoctieu nt ON nt.id_xn = xn.id_xn 

WHERE h.id_benhnhan = 47 

ORDER BY ngaykham DESC 

--Liệt kê các bác sĩ từng khám cho một bệnh nhân
SELECT DISTINCT b* FROM Bacsi b  

JOIN Hosobenhan h ON h.ID_Benhnhan = 47 AND h.id_bacsi = b.id_Bacsi;

-- Liệt kê tất cả hồ sơ bệnh án của một bệnh nhân
SELECT id_hs, id_benhnhan, id_bacsi, ngaykham  

FROM HoSoBenhAn  

WHERE ID_BenhNhan = 47

-- Liệt kê các hồ sơ bệnh án trước đó có liên quan đến cùng một bệnh của một bệnh nhân
WITH RECURSIVE HoSoCTE AS ( 

    SELECT h.id_hs, h.id_benhnhan, h.ngaykham, h.id_bacsi, h.lantruoc_id_hs 

    FROM HoSoBenhAn h 

    WHERE h.ID_HS = 84 

    UNION

    SELECT h.id_hs, h.id_benhnhan, h.ngaykham, h.id_bacsi, h.lantruoc_id_hs 

    FROM HoSoBenhAn h 

    JOIN HoSoCTE c ON c.LanTruoc_ID_HS = h.ID_HS 

    ) 

SELECT * FROM HoSoCTE;

-- Tìm hồ sơ bệnh nhân theo tên
SELECT ID_BenhNhan, HoVaTen, GioiTinh, NgaySinh, SDT, ID_BHYT, ThuocDiUng, BenhLiDacBiet 

FROM BenhNhan 

WHERE HoVaTen ILIKE '%' || 'David Johnson' || '%'

-- Liệt kê các bệnh theo số người mắc giảm dần trong một khoảng thời gian
SELECT unnest(ChanDoan) AS benh, COUNT(*) AS soluotmac 

FROM HoSoBenhAn 

WHERE NgayKham BETWEEN '2024-1-1' AND '2024-3-1' 

AND lantruoc_id_hs IS NULL 

GROUP BY benh 

ORDER BY soluotmac DESC; 