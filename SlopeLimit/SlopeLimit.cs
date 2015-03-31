using ICities;

namespace SlopeLimit
{
    public class SlopeLimitMod : IUserMod
    {
        public string Description
        {
            get { return "Lowers the allowed slope limit on roads"; }
        }

        public string Name
        {
            get { return "Slope Limiter"; }
        }
    }

    public class SlopeLimitLoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            //System.IO.File.Delete(@"RoadSlopes.csv");
            NetCollection[] netCollections = UnityEngine.Object.FindObjectsOfType<NetCollection>();
            foreach (NetCollection netCollection in netCollections)
            {
                foreach (NetInfo netInfo in netCollection.m_prefabs)
                {
                    //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"RoadSlopes.csv", true))
                    //{
                    //    file.WriteLine(netInfo.name+ "," + netInfo.m_class.name + "," + netInfo.m_maxSlope);
                    //}
                    switch (netInfo.m_class.name)
                    {
                        case "Highway":
                            netInfo.m_maxSlope = 0.07f;
                            break;
                        case "Large Road":
                            netInfo.m_maxSlope = 0.10f;
                            break;
                        case "Medium Road":
                            netInfo.m_maxSlope = 0.10f;
                            break;
                        case "Small Road":
                            netInfo.m_maxSlope = 0.15f;
                            break;
                        case "Train Track":
                            netInfo.m_maxSlope = 0.05f;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
