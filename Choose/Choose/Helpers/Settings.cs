// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Choose.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

        private const string IsLoggedInKey = "IsLoggedIn";
        public static bool IsLoggedIn
        {
            get => AppSettings.GetValueOrDefault(IsLoggedInKey, false);
            set => AppSettings.AddOrUpdateValue(IsLoggedInKey, value);
        }

        private const string AuthTokenKey = "AuthToken";
        public static string AuthToken
        {
            get => AppSettings.GetValueOrDefault<string>(AuthTokenKey);
            set => AppSettings.AddOrUpdateValue(AuthTokenKey, value);
        }

        private const string UserIdKey = "UserId";
        public static string UserId
        {
            get => AppSettings.GetValueOrDefault<string>(UserIdKey);
            set => AppSettings.AddOrUpdateValue(UserIdKey, value);
        }
    }
}