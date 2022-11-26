using System.Linq;

namespace WebAPI.BaselAPI
{
    public class BaselAPIDataBucketService
    {
        private readonly BaselAPIDataBucket baselAPIDataBucket;
        public BaselAPIDataBucketService(BaselAPIDataBucket baselAPIDataBucket)
        {
            this.baselAPIDataBucket = baselAPIDataBucket;
        }

        public BaselAPIDataBucket GetBaselAPIDataBucket()
        {
            return baselAPIDataBucket;
        }

        public BaselAPIDataBucket GetBaselAPIDataBucketForAddress(string address)
        {
            var plz = address.Split(',', ' ');
            var t = plz.Where(p => int.TryParse(p, out int i));

            if(t.Any() == false)
            {
                return baselAPIDataBucket;
            }

            var v = baselAPIDataBucket.Entsorgungsstellen.Where(e => e.plz == t.Where(t => t.Length == 4).First()).ToList();

            return new BaselAPIDataBucket
            {
                Entsorgungsstellen = baselAPIDataBucket.Entsorgungsstellen.Where(e => e.plz == t.Where(t => t.Length == 4).First()).ToList().AsEnumerable()
            };
        }
    }
}
