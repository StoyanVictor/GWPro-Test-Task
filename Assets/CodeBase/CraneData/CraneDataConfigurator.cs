public class CraneDataConfigurator
{
    private CraneData _craneData;

    public CraneDataConfigurator(CraneData craneData)
    {
        _craneData = craneData;
    }

    public void ConfigureData(CraneConfig config)
    {
        //Configurate moveSpeed
        _craneData.UpMoveSpeed = config.UpMoveSpeed;
        _craneData.DownMoveSpeed = config.DownMoveSpeed;
        _craneData.NorthMoveSpeed = config.NorthMoveSpeed;
        _craneData.SouthMoveSpeed = config.SouthMoveSpeed;
        _craneData.WestMoveSpeed = config.WestMoveSpeed;
        _craneData.EastMoveSpeed = config.EastMoveSpeed;
        // Configurate Limits
        _craneData.XMaxPos = config.XMaxPos;
        _craneData.XMinPos = config.XMinPos;
        _craneData.YMaxPos = config.YMaxPos;
        _craneData.YMinPos = config.YMinPos;
        _craneData.ZMaxPos = config.ZMaxPos;
        _craneData.zMinPos = config.zMinPos;

    }
}