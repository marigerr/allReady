﻿using AllReady.Areas.Admin.Models;
using AllReady.Models;
using AllReady.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AllReady.Areas.Admin.Features.Campaigns
{
    public class CampaignSummaryQueryHandler : IRequestHandler<CampaignSummaryQuery, CampaignSummaryModel>
    {
        private AllReadyContext _context;

        public CampaignSummaryQueryHandler(AllReadyContext context)
        {
            _context = context;

        }
        public CampaignSummaryModel Handle(CampaignSummaryQuery message)
        {
            var campaign = _context.Campaigns
                .Select(c => new CampaignSummaryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    FullDescription = c.FullDescription,
                    TenantId = c.ManagingTenantId,
                    TenantName = c.ManagingTenant.Name,
                    ImageUrl = c.ImageUrl,
                    StartDate = c.StartDateTimeUtc,
                    EndDate = c.EndDateTimeUtc
                }).SingleOrDefault(c => c.Id == message.CampaignId);
                    
            return campaign;
        }
    }
}
