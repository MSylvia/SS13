// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_Thermal : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Thermal Imaging Glasses";
			this.desc = "These goggles can be turned to resemble common eyewears throughout the station. They allow you to see organisms through walls by capturing the upper portion of the infrared light spectrum, emitted as heat and light by objects. Hotter objects, such as warm bodies, cybernetic organisms and artificial intelligence cores emit more of this light than cooler objects like walls and airlocks.";
			this.item = typeof(Obj_Item_Clothing_Glasses_Thermal_Syndi);
			this.cost = 4;
		}

	}

}