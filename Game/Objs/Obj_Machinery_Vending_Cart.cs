// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Cart : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_slogans = "Carts to go!";
			this.icon_deny = "cart-deny";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Cartridge_Medical), 10 )
				.Set( typeof(Obj_Item_Weapon_Cartridge_Engineering), 10 )
				.Set( typeof(Obj_Item_Weapon_Cartridge_Security), 10 )
				.Set( typeof(Obj_Item_Weapon_Cartridge_Janitor), 10 )
				.Set( typeof(Obj_Item_Weapon_Cartridge_Signal_Toxins), 10 )
				.Set( typeof(Obj_Item_Device_Pda_Heads), 10 )
				.Set( typeof(Obj_Item_Weapon_Cartridge_Captain), 3 )
				.Set( typeof(Obj_Item_Weapon_Cartridge_Quartermaster), 10 )
			;
			this.icon_state = "cart";
		}

		public Obj_Machinery_Vending_Cart ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}