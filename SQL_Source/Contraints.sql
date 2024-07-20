ALTER TABLE BenhNhan
ADD CONSTRAINT chk_BenhNhan_GioiTinh CHECK (GioiTinh IN ('F', 'M'));
ALTER TABLE BacSi
ADD CONSTRAINT chk_BacSi_GioiTinh CHECK (GioiTinh IN ('F', 'M'));
ALTER TABLE Mau
ADD CONSTRAINT chk_Mau_NhomMau CHECK (NhomMau IN ('AB+', 'AB-', 'A+', 'A-', 'B+', 'B-', 'O+', 'O-'));

ALTER TABLE MauThamChieu
ADD CONSTRAINT chk_MauThamChieu_SLHongCau CHECK (SLHongCauMin <= SLHongCauMax);
ALTER TABLE MauThamChieu
ADD CONSTRAINT chk_MauThamChieu_Glucose CHECK (GlucoseMin <= GlucoseMax);
ALTER TABLE NuocTieuThamChieu
ADD CONSTRAINT chk_NuocTieuThamChieu_pH CHECK (pHMin <= pHMax);
ALTER TABLE NuocTieuThamChieu
ADD CONSTRAINT chk_NuocTieuThamChieu_Glucose CHECK (GlucoseMin <= GlucoseMax);