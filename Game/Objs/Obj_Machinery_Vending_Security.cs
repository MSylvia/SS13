// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Security : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_ads = "Crack capitalist skulls!;Beat some heads in!;Don't forget - harm is good!;Your weapons are right here.;Handcuffs!;Freeze, scumbag!;Don't tase me bro!;Tase them, bro.;Why not have a donut?";
			this.icon_deny = "sec-deny";
			this.req_access_txt = "1";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Restraints_Handcuffs), 8 )
				.Set( typeof(Obj_Item_Weapon_Restraints_Handcuffs_Cable_Zipties), 10 )
				.Set( typeof(Obj_Item_Weapon_Grenade_Flashbang), 4 )
				.Set( typeof(Obj_Item_Device_Assembly_Flash_Handheld), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut), 12 )
				.Set( typeof(Obj_Item_Weapon_Storage_Box_Evidence), 6 )
				.Set( typeof(Obj_Item_Device_Flashlight_Seclite), 4 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Clothing_Glasses_Sunglasses), 2 ).Set( typeof(Obj_Item_Weapon_Storage_Fancy_DonutBox), 2 );
			this.premium = new ByTable().Set( typeof(Obj_Item_Weapon_Coin_Antagtoken), 1 );
			this.icon_state = "sec";
		}

		public Obj_Machinery_Vending_Security ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}