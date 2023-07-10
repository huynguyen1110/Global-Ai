using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.ThuocTinh;
using GlobalAI.ProductEntities.Dto.ThuocTinhGiaTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Interfaces
{
    public interface IThuocTinhServices
    {
        public ThuocTinh AddThuocTinh(AddThuocTinhDto dto);
        public void UpdateThuocTinh(UpdateThuocTinhDto dto);
        public void DeleteThuocTinh(int id);
        public ViewThuocTinhDto FindThuocTinhById(int id);
        public List<ViewThuocTinhDto> FindListThuocTinhByDanhMuc(int idDanhMuc);
        public ThuocTinhGiaTri AddGiaTri(AddThuocTinhGiaTriDto dto);
        public void UpdateGiaTri(UpdateThuocTinhGiaTriDto dto);
        public void DeleteGiaTri(int id);
        public ViewThuocTinhGiaTriDto FindGiaTriById(int id);
        public List<ViewThuocTinhGiaTriDto> FindListGiaTriByThuocTinh(int idDanhMuc);
    }
}
