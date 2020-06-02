using FJ.Data.Repositories.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FJ.BusinessLogics
{
    public class BaseBL
    {
        private AdapterFJRepository _AdapterFJRepository;
        protected AdapterFJRepository AdapterFJRepository
        {
            get
            {
                if (_AdapterFJRepository == null) 
                {
                    _AdapterFJRepository = new AdapterFJRepository();
                }
                return _AdapterFJRepository;
            }
        }

        public void Save()
        {
            this.AdapterFJRepository.Save();
        }
    }
}