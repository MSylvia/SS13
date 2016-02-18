// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Drone_Syndrone : Mob_Living_SimpleAnimal_Drone {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "drone_synd";
			this.picked = 1;
			this.maxHealth = 120;
			this.faction = new ByTable(new object [] { "syndicate" });
			this.speak_emote = new ByTable(new object [] { "hisses" });
			this.bubble_icon = "syndibot";
			this.heavy_emp_damage = 10;
			this.laws = "1. Interfere.\n2. Kill.\n3. Destroy.";
			this.default_storage = typeof(Obj_Item_Device_Radio_Uplink);
			this.default_hatmask = typeof(Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Syndi);
			this.seeStatic = 0;
			this.icon_state = "drone_synd";
		}

		// Function from file: extra_drone_types.dm
		public Mob_Living_SimpleAnimal_Drone_Syndrone ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.internal_storage.hidden_uplink.telecrystals = 10;
			return;
		}

		// Function from file: extra_drone_types.dm
		public override dynamic Login(  ) {
			base.Login();
			this.WriteMsg( "<span class='notice'>You can kill and eat other drones to increase your health!</span>" );
			return null;
		}

	}

}