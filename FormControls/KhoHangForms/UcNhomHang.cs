﻿using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace QLDT.FormControls.KhoHangForms
{
    public partial class UcNhomHang : BaseUserControl
    {
        private readonly DanhMuc _domainData;
        private readonly Define.LoaiDanhMucEnum _loaiDanhMuc;

        public UcNhomHang(Define.LoaiDanhMucEnum loaidDanhMuc, DanhMuc data = null)
        {
            InitializeComponent();

            Init(data);
            _domainData = data;
            _loaiDanhMuc = loaidDanhMuc;
        }

        public override bool SaveData()
        {
            var validateResult = ValidateInput();
            if (!string.IsNullOrEmpty(validateResult))
            {
                MessageBox.Show(validateResult);
                return false;
            }

            var saveData = CRUD.GetFormObject<DanhMuc>(FormControls);
            saveData.Loai = _loaiDanhMuc.ToString();
            CRUD.DecorateSaveData(saveData, _domainData);
            CRUD.DbContext.DanhMucs.AddOrUpdate(saveData);
            CRUD.DbContext.SaveChanges();

            return true;
        }

        public string ValidateInput()
        {
            if (string.IsNullOrEmpty(DanhMuc_Ten.Text))
            {
                return string.Format("{0} {1}!", "Không được phép để trống", lblTen.Text);
            }
            if (CheckDuplicate(DanhMuc_Ten.Text))
            {
                return string.Format("{0} {1}!", DanhMuc_Ten.Text, "đã tồn tại trong hệ thống");
            }
            return string.Empty;
        }

        private bool CheckDuplicate(string tenDanhMuc)
        {

            var checkData = tenDanhMuc.Trim();
            if (_domainData != null)
            {
                return CRUD.DbContext.DanhMucs.Any(s => s.Id != _domainData.Id && s.Ten == checkData);
            }
            return CRUD.DbContext.DanhMucs.Any(s => s.Ten == checkData);

        }
    }
}
