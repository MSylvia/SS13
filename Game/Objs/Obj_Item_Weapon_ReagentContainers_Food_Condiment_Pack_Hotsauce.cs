// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack_Hotsauce : Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.originalname = "hotsauce";
			this.list_reagents = new ByTable().Set( "capsaicin", 10 );
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack_Hotsauce ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}