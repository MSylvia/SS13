// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paper_Range : Obj_Item_Weapon_Paper {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.info = "Directions:<br><i>First you'll want to make sure there is a target stake in the center of the magnetic platform. Next, take an aluminum target from the crates back there and slip it into the stake. Make sure it clicks! Next, there should be a control console mounted on the wall somewhere in the room.<br><br> This control console dictates the behaviors of the magnetic platform, which can move your firing target around to simulate real-world combat situations. From here, you can turn off the magnets or adjust their electromagnetic levels and magnetic fields. The electricity level dictates the strength of the pull - you will usually want this to be the same value as the speed. The magnetic field level dictates how far the magnetic pull reaches.<br><br>Speed and path are the next two settings. Speed is associated with how fast the machine loops through the designated path. Paths dictate where the magnetic field will be centered at what times. There should be a pre-fabricated path input already. You can enable moving to observe how the path affects the way the stake moves. To script your own path, look at the following key:</i><br><br>N: North<br>S: South<br>E: East<br>W: West<br>C: Center<br>R: Random (results may vary)<br>; or &: separators. They are not necessary but can make the path string better visible.";
		}

		public Obj_Item_Weapon_Paper_Range ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}