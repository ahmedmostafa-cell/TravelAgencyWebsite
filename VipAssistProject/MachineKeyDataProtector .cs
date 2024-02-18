using Microsoft.AspNetCore.DataProtection;
using Microsoft.Owin.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipAssistProject
{
   

internal class MachineKeyProtectionProvider : IDataProtectionProvider
    {
        public IDataProtector Create(params string[] purposes)
        {
            return new MachineKeyDataProtector(purposes);
        }

        public IDataProtector CreateProtector(string purpose)
        {
            throw new NotImplementedException();
        }
    }

    internal class MachineKeyDataProtector : IDataProtector
    {
        private readonly string[] _purposes;

        public MachineKeyDataProtector(string[] purposes)
        {
            _purposes = purposes;
        }

        public IDataProtector CreateProtector(string purpose)
        {
            throw new NotImplementedException();
        }

        public byte[] Protect(byte[] userData)
        {
            //return MachineKey.Protect(userData, _purposes);
            return userData;
        }

        public byte[] Unprotect(byte[] protectedData)
        {
            //return System.Web.Security.MachineKey.Unprotect(protectedData, _purposes);
            return protectedData;
        }
    }
}
