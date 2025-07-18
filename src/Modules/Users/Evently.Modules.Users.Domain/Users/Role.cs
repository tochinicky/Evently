using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evently.Modules.Users.Domain.Users;
public sealed class Role
{
    public static readonly Role Administrator = new("Administrator");
    public static readonly Role Member = new("Member");

    public string Name { get; private set; }
    private Role(string name)
    {
            Name = name ?? throw new ArgumentNullException(nameof(name));
    }
    private Role()
    {
            
    }
}
