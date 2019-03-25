using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BusinessLogicClass
    {
        DataAccessLayer.DataAccessClass daObj = new DataAccessLayer.DataAccessClass();
        public void Insert(BusinessEntityLayer.BusinessEntityClass obj)
        {
            daObj.Insert(obj);
        }
        public void Update(BusinessEntityLayer.BusinessEntityClass obj)
        {
            daObj.Update(obj);
        }
        public DataRow FindName(string name)
        {
            return daObj.FindName(name);
        }

        public DataTable GetList()
        {
            return daObj.AddressBookList();
        }
        public void Delete(int id)
        {
            daObj.Delete(id);
        }
        public int BindId()
        {
          return  daObj.Bindid();
        }
    }
}
