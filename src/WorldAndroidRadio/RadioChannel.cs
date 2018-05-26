using System.Collections.Generic;
using System.Linq;

namespace WorldAndroidRadio
{
    //Declaring Radio Channel Property
    public class RadioChannel
    {
        public string Country { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
    public class ListRadio
    {
        string Country = string.Empty;
        public ListRadio() { }
        public ListRadio(string Country)
        {
            this.Country = Country;
        }
        //This function will return all Country
        public List<RadioChannel> GetAllCountry()
        {
            return lstRadio.GroupBy(p => p.Country).Select(grp => grp.FirstOrDefault()).OrderBy(x => x.Country).ToList();
        }
        //This Function will Return Country wise Channellist
        public List<RadioChannel> GetCountryWiseRadio()
        {
            return lstRadio.Where(p => p.Country == Country).OrderBy(x => x.Name).ToList();
        }
        //This will Return all Radio Channel
        public List<RadioChannel> GetAllRadio()
        {
            return lstRadio.OrderBy(x => x.Name).ToList();
        }
        //Radio Channel List
        List<RadioChannel> lstRadio = new List<RadioChannel>()
        {
            // Channnel of Indonesia
           new RadioChannel {  Country = "Indonesia", Name = "ANDIKA FM",  Url = "http://stream2.andikafm.com:1057/andikafm" },
           new RadioChannel {  Country = "Indonesia", Name = "ACTARI FM CIAMIS",  Url = "http://stream.suararadio.com:8000/ciamis_actarifm_mp3" },
           new RadioChannel {  Country = "Indonesia", Name = "ADS Radio",  Url = "http://175.103.56.9:8009/" },
           new RadioChannel {  Country = "Indonesia", Name = "Aje Radio",  Url = "http://u.klikhost.com:7854/;stream.mp3" },
           new RadioChannel {  Country = "Indonesia", Name = "Amboi FM",  Url = "http://72.20.10.60:8000" },
           new RadioChannel {  Country = "Indonesia", Name = "An Nabawi Radio",  Url = "http://rosetta.shoutca.st:8313" },
           new RadioChannel {  Country = "Indonesia", Name = "Annabawi FM",  Url = "http://listen.shoutcast.com/annabawiyahfm" },
           new RadioChannel {  Country = "Indonesia", Name = "Ardan Radio",  Url = "http://listento.ardanradio.com:1059" },
           new RadioChannel {  Country = "Indonesia", Name = "ARRIE Radio",  Url = "http://45.64.97.82:8216" },

            // Channnel of Canada
           new RadioChannel {  Country = "Canada", Name = "SoundFM",  Url = "http://192.240.102.133:7703/stream" },
           new RadioChannel {  Country = "Canada", Name = "Cruz FM",  Url = "https://aispool.streamon.fm/ais/CHFT.aac" },
           new RadioChannel {  Country = "Canada", Name = "Big FM",  Url = "http://live.leanstream.co/CIQBFM" },
           new RadioChannel {  Country = "Canada", Name = "101.3 Kool FM",  Url = "http://newcap.leanstream.co/CJEGFM" },
           new RadioChannel {  Country = "Canada", Name = "101.5 Kool FM",  Url = "http://ais.streamon.fm:8000/ais/CKCE-48k.aac" },
           new RadioChannel {  Country = "Canada", Name = "The GIANT",  Url = "http://newcap.leanstream.co/CHRKFM" },

            // Channnel of Bangladesh
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Foorti",  Url = "http://119.148.23.88:1021/;stream/1" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Today",  Url = "http://stream.zenolive.com/8wv4d8g4344tv" },
           new RadioChannel {  Country = "Bangladesh", Name = "Dhaka FM",  Url = "http://118.179.219.244:8000" },
           new RadioChannel {  Country = "Bangladesh", Name = "Abc Radio",  Url = "http://stream.zenolive.com/6a28tbx6vewtv" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Bhumi",  Url = "http://noasrv.caster.fm:10182/live" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Shongi",  Url = "http://162.254.150.34:7031" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Sarabela",  Url = "http://162.254.149.146:9308/stream" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Mahananda",  Url = "http://cast.nawabhost.com:8010/stream" },
           new RadioChannel {  Country = "Bangladesh", Name = "Bangla Wadio",  Url = "http://162.254.150.34:8201/" },
           new RadioChannel {  Country = "Bangladesh", Name = "Bangladesh Betar",  Url = "http://192.235.87.105:14322/" },
           new RadioChannel {  Country = "Bangladesh", Name = "Lemon 24",  Url = "http://office.mcc.com.bd:8000" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio 2Fun",  Url = "http://216.107.153.51:8000/airtime_128" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Deshi", Url = "http://37.187.79.93:8016/live" },
           new RadioChannel {  Country = "Bangladesh", Name = "Radio Kotha", Url = "http://188.165.201.120:8016/stream" },
           new RadioChannel {  Country = "Bangladesh", Name = "Jago FM",  Url = "http://192.240.102.133:12110/;stream/1" },

            // Channnel of Turkey
           new RadioChannel {  Country = "Turkey", Name = "Antakya Radyo Renk", Url = "http://yayin1.yayindakiler.com:3016/renk" },
           new RadioChannel {  Country = "Turkey", Name = "Akustikland FM", Url = "http://46.20.3.246/stream/45/" },
           new RadioChannel {  Country = "Turkey", Name = "Afyon Radyo Sultan", Url = "http://217.182.229.204:9920/" },
           new RadioChannel {  Country = "Turkey", Name = "Afsin Radyo", Url = "http://sunucu.radyodinle.com:4242/" },
           new RadioChannel {  Country = "Turkey", Name = "Adana FM", Url = "http://onlineradyotv.net:9000/adanafm.stream" },
           new RadioChannel {  Country = "Turkey", Name = "45lik Radyo", Url = "http://gitassi.radyolarburada.com:3090/" },
           new RadioChannel {  Country = "Turkey", Name = "90.6 Radyo 2000", Url = "http://sunucu2.radyolarburada.com:4848/" },
           new RadioChannel {  Country = "Turkey", Name = "74 Bartin FM", Url = "http://95.173.162.188:9824/" },
           new RadioChannel {  Country = "Turkey", Name = "24 Arabesk", Url = "http://yayin.24arabesk.com:9399" },
           new RadioChannel {  Country = "Turkey", Name = "08 Haber", Url = "http://yayin.netyayin.net:8008/" },
           new RadioChannel {  Country = "Turkey", Name = "1001 FM", Url = "http://yayin3.canlitv.com:9050/" },
           new RadioChannel {  Country = "Turkey", Name = "Arabesk Turk", Url = "http://37.247.101.101:5934/" },
           new RadioChannel {  Country = "Turkey", Name = "Arabesk Turkiye", Url = "http://arabeskturkiye.xyz:9312/" }
        };
    }
}