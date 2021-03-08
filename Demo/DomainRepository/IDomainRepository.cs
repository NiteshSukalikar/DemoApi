using DemoData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DomainRepository
{
    public interface IDomainRepository
    {
        DomainVM GetDomain(int id);

        IEnumerable<DomainVM> GetDomains();

        DomainVM addDomain(DomainVM domainVM);

        DomainVM deleteDomain(int id);

        DomainVM EditDomain(int id, DomainVM domainVM);


    }
}
