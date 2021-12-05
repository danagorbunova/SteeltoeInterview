using AdminApi.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminApi.Messaging
{
    public class UserEvent
    {
        public enum State
        {
            Added,
            Modified,
            Deleted
        }

        public User User { get; }

        internal State StateKey { get; }

        [JsonProperty("State")]
        public string StateName => StateKey.ToString();

        public UserEvent(State state, User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            StateKey = state;
            User = user;
        }

        public string ToJsonString()
        {
            return JToken.FromObject(this).ToString();
        }
    }
}