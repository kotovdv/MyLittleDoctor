namespace MyLittleDoctor.Configuration
{
    public class GameConfig
    {
        public readonly PlayerConfig PlayerConfig;
        public readonly ControlsConfig ControlsConfig;

        public GameConfig(PlayerConfig playerConfig, ControlsConfig controlsConfig)
        {
            PlayerConfig = playerConfig;
            ControlsConfig = controlsConfig;
        }
    }
}