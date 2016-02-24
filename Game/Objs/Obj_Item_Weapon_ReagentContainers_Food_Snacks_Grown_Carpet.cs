// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carpet : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Carpetseed);
			this.icon_state = "carpetclump";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carpet ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			double? carpetAmt = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carpet C = null;
			Obj_Item_Stack_Tile_Carpet CT = null;
			Obj_Item_Stack_Tile_Carpet CA = null;

			user.WriteMsg( "<span class='notice'>You roll out the red carpet.</span>" );
			carpetAmt = Num13.Floor( ( this.potency ??0) / 50 ) + 1;

			foreach (dynamic _a in Lang13.Enumerate( user.loc, typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carpet) )) {
				C = _a;
				
				carpetAmt += Num13.Floor( ( C.potency ??0) / 50 ) + 1;
				GlobalFuncs.qdel( C );
			}

			while (( carpetAmt ??0) > 0) {
				CT = new Obj_Item_Stack_Tile_Carpet( user.loc );

				if ( ( carpetAmt ??0) >= ( CT.max_amount ??0) ) {
					CT.amount = CT.max_amount;
				} else {
					CT.amount = carpetAmt;

					foreach (dynamic _b in Lang13.Enumerate( user.loc, typeof(Obj_Item_Stack_Tile_Carpet) )) {
						CA = _b;
						

						if ( CA != CT && ( CA.amount ??0) < ( CA.max_amount ??0) ) {
							CA.attackby( CT, user );
						}
					}
				}
				carpetAmt -= CT.max_amount ??0;
			}
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}