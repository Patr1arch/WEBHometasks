using System;
using System.Collections.Generic;
using System.Text;

namespace WebHometask2
{
    public class CompanyManager
    {
        List<Company> companyList;
        public void MakeCompany(decimal id, string name)
        {
            Company company = new Company(id, name);
            companyList.Add(company);
        }

        public CompanyManager()
        {
            companyList = new List<Company>();
        }

        public void EditCompany(decimal id, string editName) => companyList[companyList.FindIndex(0, companyList.Count,
            g => g.id == id)].name = editName;

        public void DeleteCompany(decimal id) => companyList.Remove(companyList.Find(g => g.id == id));

        public Company GetCompanyById(decimal id) { return companyList.Find(g => g.id == id); }

        public List<Company> GetAllCompanies() { return this.companyList; }
    }
}
