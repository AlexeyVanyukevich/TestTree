using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tree.Domain.Models;

namespace Tree.Persistence.Interfaces;
internal interface IBaseRepository<TBase> where TBase : Base {
}
