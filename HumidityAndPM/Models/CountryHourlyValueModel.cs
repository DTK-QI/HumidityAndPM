namespace HumidityAndPM.Models
{
    public class CountryHourlyViewModel
    {

        public new List<CountryHourlyValueModel> records { get; set; }
        public object fields { get; set; }
    }

    public class CountryHourlyValueModel
    {
        /// <summary>
        /// 測站代碼
        /// </summary>
        /// 
        public string? siteid { get; set; }
        /// <summary>
        /// 測站名稱
        /// </summary>
        public string? sitename { get; set; }
        /// <summary>
        /// 縣市
        /// </summary>
        public string? county { get; set; }
        /// <summary>
        /// 測項代碼
        /// </summary>
        public string? itemid { get; set; }
        /// <summary>
        /// 測項名稱
        /// </summary>
        public string? itemname { get; set; }
        /// <summary>
        /// 測項英文名稱
        /// </summary>
        public string? itemengname { get; set; }
        /// <summary>
        /// 測項單位
        /// </summary>
        public string? itemunit { get; set; }
        /// <summary>
        /// 監測日期
        /// </summary>
        public DateTime? monitordate { get; set; }
        /// <summary>
        /// 數值
        /// </summary>
        public float? concentration { get; set; }
    }
}
