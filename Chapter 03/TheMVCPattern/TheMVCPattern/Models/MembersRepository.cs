using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMVCPattern.Models {
    public class MembersRepository : IMembersRepository {
        public void AddMember(Member member) { 
            /* Implement me */ 
        }
        public Member FetchByLoginName(string loginName) { 
            /* Implement me */ return null; 
        }
        public void SubmitChanges() { 
            /* Implement me */ 
        }
    }
}