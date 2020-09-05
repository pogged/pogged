using pogged.Model;
using pogged.Model.Xml;

namespace pogged
{
    public class Serializer
    {
        public Channel ToChannel(XChannel input)
        {
            Channel output = new Channel();

            // Currently there no properties, that can serialized.

            return output;
        }

        public static Episode ToEpisode(XItem input)
        {
            Episode output = new Episode();

            output.Title = input.Title[0];

            return output;
        }
    }
}
