// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Zone_TurretProtected_Tcomsat : Zone_TurretProtected {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ambientsounds = new ByTable(new object [] { "sound/ambience/ambisin2.ogg", "sound/ambience/signal.ogg", "sound/ambience/signal.ogg", "sound/ambience/ambigen10.ogg" });
			this.icon_state = "tcomsatlob";
		}

		public Zone_TurretProtected_Tcomsat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}