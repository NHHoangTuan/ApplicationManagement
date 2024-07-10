﻿using ApplicationManagement.DAO;
using ApplicationManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.BUS
{
    internal class RecruitmentBUS
    {

        private RecruitFormDAO _recruitFormDAO;


        public RecruitmentBUS()
        {
            _recruitFormDAO = new RecruitFormDAO();
        }


        public BindingList<RecruitmentDTO> getAllRecruitment()
        {
            return _recruitFormDAO.getAllRecruitment();
        }

    }
}
