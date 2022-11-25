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

        public BaselAPIDataBucket GetBaselAPIDataBucketFilteredByPlz(int plz)
        {
            return baselAPIDataBucket;
        }
    }
}
