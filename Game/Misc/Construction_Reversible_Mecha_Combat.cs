// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_Reversible_Mecha_Combat : Construction_Reversible_Mecha {

		public Type targeting = typeof(Obj_Item_Weapon_Circuitboard_Mecha_Gygax_Targeting);
		public Type armor_plates = typeof(Obj_Item_MechaParts_Part_GygaxArmour);

		protected override void __FieldInit() {
			base.__FieldInit();

			this.steps = new ByTable(new object [] { 
				new ByTable()
					.Set( "desc", "External armor is wrenched." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "amount", 3 ).Set( "vis_msg", "{USER} weld{s} armor plates to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} unfasten{s} the armor plates." ) )
				, 
				new ByTable()
					.Set( "desc", "External armor is installed." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} secure{s} armor plates." ) )
					.Set( "backstep", new ByTable()
						.Set( "key", typeof(Obj_Item_Weapon_Crowbar) )
						.Set( "vis_msg", "{USER} prie{s} armor plates from {HOLDER}." )
						.Set( "delay", 30 )
						.Set( "start_msg", "{USER} begin{s} removing the armor plates..." )
					 )
				, 
				new ByTable()
					.Set( "desc", "Internal armor is welded." )
					.Set( "nextstep", new ByTable()
						.Set( "key", null )
						.Set( "amount", 1 )
						.Set( "vis_msg", "{USER} install{s} armor plates to {HOLDER}." )
						.Set( "start_msg", "{USER} begin{s} installing the armor plates..." )
						.Set( "delay", 30 )
					 )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "amount", 3 ).Set( "vis_msg", "{USER} cut{s} internal armor layer from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Internal armor is wrenched" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "amount", 3 ).Set( "vis_msg", "{USER} weld{s} internal armor layer to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} unfasten{s} the internal armor layer." ) )
				, 
				new ByTable()
					.Set( "desc", "Internal armor is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} secure{s} internal armor layer." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} prie{s} internal armor layer from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Advanced capacitor is secured" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Stack_Sheet_Metal) ).Set( "amount", 5 ).Set( "vis_msg", "{USER} install{s} internal armor layer to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} unfasten{s} the advanced capacitor." ) )
				, 
				new ByTable()
					.Set( "desc", "Advanced capacitor is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} secure{s} the advanced capacitor." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} remove{s} the advanced capacitor from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Advanced scanner module is secured" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_StockParts_Capacitor_Adv) ).Set( "amount", 1 ).Set( "vis_msg", "{USER} install{s} advanced capacitor to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} unfasten{s} the Advanced scanner module." ) )
				, 
				new ByTable()
					.Set( "desc", "Advanced scanner module is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} secure{s} the advanced scanner module." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} remove{s} the advanced scanner module from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Targeting module is secured" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_StockParts_ScanningModule_Adv) ).Set( "amount", 1 ).Set( "vis_msg", "{USER} install{s} advanced scanner module to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} unfasten{s} the targeting module." ) )
				, 
				new ByTable()
					.Set( "desc", "Targeting module is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} secure{s} the targeting module." ) )
					.Set( "Co_BACKSTOP", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} remove{s} the targeting module from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Peripherals control module is secured" )
					.Set( "nextstep", new ByTable().Set( "key", null ).Set( "amount", 1 ).Set( "vis_msg", "{USER} install{s} the targeting module into {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} unfasten{s} the peripherals control module." ) )
				, 
				new ByTable()
					.Set( "desc", "Peripherals control module is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} secure{s} the peripherals control module." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} remove{s} the peripherals control module from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "Central control module is secured" )
					.Set( "nextstep", new ByTable().Set( "key", null ).Set( "amount", 1 ).Set( "vis_msg", "{USER} install{s} the peripherals control module into {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} unfasten{s} the mainboard." ) )
				, 
				new ByTable()
					.Set( "desc", "Central control module is installed" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} secure{s} the mainboard." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Crowbar) ).Set( "vis_msg", "{USER} remove{s} the central control module from {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "The wiring is adjusted" )
					.Set( "nextstep", new ByTable().Set( "key", null ).Set( "amount", 1 ).Set( "vis_msg", "{USER} install{s} the central control module into {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} disconnect{s} the wiring of {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "The wiring is added" )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wirecutters) ).Set( "vis_msg", "{USER} adjust{s} the wiring of {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} remove{s} the wiring of {HOLDER}." ) )
				, 
				new ByTable()
					.Set( "desc", "The hydraulic systems are active." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Stack_CableCoil) ).Set( "amount", 10 ).Set( "vis_msg", "{USER} add{s} the wiring to {HOLDER}." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} deactivate{s} {HOLDER} hydraulic systems." ) )
				, 
				new ByTable()
					.Set( "desc", "The hydraulic systems are connected." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "vis_msg", "{USER} activate{s} {HOLDER} hydraulic systems." ) )
					.Set( "backstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} disconnect{s} {HOLDER} hydraulic systems." ) )
				, 
				new ByTable()
					.Set( "desc", "The hydraulic systems are disconnected." )
					.Set( "nextstep", new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "vis_msg", "{USER} connect{s} {HOLDER} hydraulic systems." ) )
				
			 });
		}

		public Construction_Reversible_Mecha_Combat ( Ent_Static atom = null ) : base( atom ) {
			
		}

		// Function from file: mecha_construction_paths.dm
		public override void add_board_keys(  ) {
			dynamic board_step = null;

			board_step = this.get_forward_step( this.steps.len - 4 );
			board_step["key"] = this.mainboard;
			board_step = this.get_forward_step( this.steps.len - 6 );
			board_step["key"] = this.peripherals;
			board_step = this.get_forward_step( this.steps.len - 8 );
			board_step["key"] = this.targeting;

			if ( this.armor_plates != null ) {
				board_step = this.get_forward_step( this.steps.len - 17 );
				board_step["key"] = this.armor_plates;
			}
			return;
		}

	}

}