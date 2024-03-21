﻿using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Interfaces
{
    /// <summary>
    /// 老人信息
    /// </summary>
    public interface ISeniorRepostory
    {
   
        public Task<List<SeniorInfo>> GetSeniors(SeniorSearch searchParam);
        public Task<SeniorInfo> CreateSenior(SeniorInfo seniorInfo);
    }
}