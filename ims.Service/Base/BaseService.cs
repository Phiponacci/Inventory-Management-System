﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ims.Core.UnitOfWorks;

namespace ims.Service.Base
{
    public class BaseService
    {
        public readonly IUnitOfWorks _unitOfWork;
        public readonly IMapper _mapper;

        public BaseService(IUnitOfWorks unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
