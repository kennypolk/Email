using System.Collections.Generic;

namespace Email.Service.Interfaces
{
    public interface IMergeCodeService
    {
        List<Dictionary<string, string>> GetMergeCodes();
    }
}
