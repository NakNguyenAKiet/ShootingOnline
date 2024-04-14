using deVoid.Utils;
using System.Collections.Generic;
namespace ShootingGame
{
    public class TurnOnCrossHair:ASignal<bool> { }    
    public class UpdateEnergy:ASignal<float> { }    
    public class UpdateHP:ASignal<float> { }    
    public class SetSpellEquipmentUI:ASignal<List<ItemInventory>> { }    
}
