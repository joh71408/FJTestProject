using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FJ.Data.EntityFrameworks;
using FJ.Data.Repositories.Tables;

namespace FJ.Data.Repositories.Adapter
{
    public partial class AdapterFJRepository
    {
        private FrogJumpEntities _FrogJumpEntities;
        private FrogJumpEntities FrogJumpEntities
        {
            get
            {
                if (_FrogJumpEntities == null)
                {
                    _FrogJumpEntities = new FrogJumpEntities();
                }
                return _FrogJumpEntities;
            }
            
        }

        private AccountRepository _AccountRepository;
        public AccountRepository AccountRepository
        {
            get
            {
                if (_AccountRepository == null)
                {
                    _AccountRepository = new AccountRepository(FrogJumpEntities);
                }
                return _AccountRepository;
            }
        }

        private CategoryRepository _CategoryRepository;
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_CategoryRepository == null)
                {
                    _CategoryRepository = new CategoryRepository(FrogJumpEntities);
                }
                return _CategoryRepository;
            }
        }

        private InentoryRepository _InentoryRepository;
        public InentoryRepository InentoryRepository
        {
            get
            {
                if (_InentoryRepository == null)
                {
                    _InentoryRepository = new InentoryRepository(FrogJumpEntities);
                }
                return _InentoryRepository;
            }
        }

        private OrderRepository _OrderRepository;
        public OrderRepository OrderRepository
        {
            get
            {
                if (_OrderRepository == null)
                {
                    _OrderRepository = new OrderRepository(FrogJumpEntities);
                }
                return _OrderRepository;
            }
        }

        private Order_DetailRepository _Order_DetailRepository;
        public Order_DetailRepository Order_DetailRepository
        {
            get
            {
                if (_Order_DetailRepository == null)
                {
                    _Order_DetailRepository = new Order_DetailRepository(FrogJumpEntities);
                }
                return _Order_DetailRepository;
            }
        }

        //private ParameterRepository _ParameterRepository;
        //public ParameterRepository ParameterRepository
        //{
        //    get
        //    {
        //        if (_ParameterRepository != null)
        //        {
        //            _ParameterRepository = new ParameterRepository(FrogJumpEntities);
        //        }
        //        return _ParameterRepository;
        //    }
        //}

        private ProductRepository _ProductRepository;
        public ProductRepository ProductRepository
        {
            get
            {
                if (_ProductRepository == null)
                {
                    _ProductRepository = new ProductRepository(FrogJumpEntities);
                }
                return _ProductRepository;
            }
        }

        private ShelfRepository _ShelfRepository;
        public ShelfRepository ShelfRepository
        {
            get
            {
                if (_ShelfRepository == null)
                {
                    _ShelfRepository = new ShelfRepository(FrogJumpEntities);
                }
                return _ShelfRepository;
            }
        }

        private WineryRepository _WineryRepository;
        public WineryRepository WineryRepository
        {
            get
            {
                if (_WineryRepository == null)
                {
                    _WineryRepository = new WineryRepository(FrogJumpEntities);
                }
                return _WineryRepository;
            }
        }

        public void Save()
        {
            this.FrogJumpEntities.SaveChanges();
        }
    }
}
