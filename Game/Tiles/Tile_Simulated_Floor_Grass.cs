// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Grass : Tile_Simulated_Floor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.floor_tile = typeof(Obj_Item_Stack_Tile_Grass);
			this.broken_states = new ByTable(new object [] { "sand" });
			this.icon_state = "grass";
		}

		// Function from file: fancy_floor.dm
		public Tile_Simulated_Floor_Grass ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 1, (Task13.Closure)(() => {
				this.update_icon();
				return;
			}));
			return;
		}

		// Function from file: fancy_floor.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( Lang13.Bool( base.attackby( (object)(A), (object)(user), _params, silent, replace_spent ) ) ) {
				return null;
			}

			if ( A is Obj_Item_Weapon_Shovel ) {
				new Obj_Item_Weapon_Ore_Glass( this );
				new Obj_Item_Weapon_Ore_Glass( this );
				user.WriteMsg( "<span class='notice'>You shovel the grass.</span>" );
				this.make_plating();
			}
			return null;
		}

	}

}