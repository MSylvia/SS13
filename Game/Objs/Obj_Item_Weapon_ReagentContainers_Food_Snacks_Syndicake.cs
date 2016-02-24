// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Syndicake : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_SyndiCakes);
			this.list_reagents = new ByTable().Set( "nutriment", 4 ).Set( "doctorsdelight", 5 );
			this.filling_color = "#F5F5DC";
			this.icon_state = "syndi_cakes";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Syndicake ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}