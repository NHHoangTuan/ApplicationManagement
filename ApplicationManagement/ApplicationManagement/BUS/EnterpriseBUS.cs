using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.BUS
{
    class EnterpriseBUS
    {

        private EnterpriseDAO enterpriseDAO;

        public EnterpriseBUS()
        {
            enterpriseDAO = new EnterpriseDAO();
        }


        public void AddEnterpriseAccount(EnterpriseDTO enterprise, string username, string password)
        {
            enterpriseDAO.AddEnterpriseAccount(enterprise, username, password);
        }


        public EnterpriseDTO getEnterpriseByTaxID(string taxID)
        {
            return enterpriseDAO.getEnterpriseByTaxID(taxID);
        }

        public string uploadImage(FileInfo selectedImage, string taxID, string key)
        {
            enterpriseDAO.updateImage(taxID, key);

            var folder = AppDomain.CurrentDomain.BaseDirectory;

            var filePath = $"{folder}/Assets/Images/Data/{key}.png";
            var relativePath = $"Assets/Images/Data/{key}.png";

            File.Copy(selectedImage.FullName, filePath);

            return relativePath;
        }

        public BindingList<EnterpriseDTO> getAllEnterprise()
        {
            return enterpriseDAO.getAllEnterprise();
        }


    }
}
