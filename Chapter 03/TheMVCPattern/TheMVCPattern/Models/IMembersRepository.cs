using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheMVCPattern.Models {
    public interface IMembersRepository {

        void AddMember(Member member);
        Member FetchByLoginName(string loginName);
        void SubmitChanges();
    }
}
