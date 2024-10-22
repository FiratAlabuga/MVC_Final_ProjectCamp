﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetTalents();
        void Insert(Talent talent);
        void Update(Talent talent);
        void Delete(Talent talent);
        Talent GetByID(int id);
    }
}
