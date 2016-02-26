// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortableAtmospherics : Obj_Machinery {

		public GasMixture air_contents = null;
		public dynamic connected_port = null;
		public dynamic holding = null;
		public int volume = 0;
		public int? destroyed = 0;
		public double maximum_pressure = 9119.25;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.icon = "icons/obj/atmos.dmi";
		}

		// Function from file: portable_atmospherics.dm
		public Obj_Machinery_PortableAtmospherics ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.SSair.atmos_machinery.Add( this );
			this.air_contents = new GasMixture();
			this.air_contents.volume = this.volume;
			this.air_contents.temperature = 293.41;
			return; // Warning! Attempt to return some other value!
		}

		// Function from file: portable_atmospherics.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic T = null;
			dynamic possible_port = null;

			
			if ( A is Obj_Item_Weapon_Tank && !Lang13.Bool( this.destroyed ) ) {
				T = A;

				if ( Lang13.Bool( this.holding ) || !Lang13.Bool( user.drop_item() ) ) {
					return null;
				}
				T.loc = this;
				this.holding = T;
				this.update_icon();
			} else if ( A is Obj_Item_Weapon_Wrench ) {
				
				if ( Lang13.Bool( this.connected_port ) ) {
					this.disconnect();
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );
					((Ent_Static)user).visible_message( "" + user + " disconnects " + this + ".", "<span class='notice'>You unfasten " + this + " from the port.</span>", "<span class='italics'>You hear a ratchet.</span>" );
					this.update_icon();
					return null;
				} else {
					possible_port = Lang13.FindIn( typeof(Obj_Machinery_Atmospherics_Components_Unary_PortablesConnector), this.loc );

					if ( !Lang13.Bool( possible_port ) ) {
						user.WriteMsg( "<span class='notice'>Nothing happens.</span>" );
						return null;
					}

					if ( !this.connect( possible_port ) ) {
						user.WriteMsg( "<span class='notice'>" + this.name + " failed to connect to the port.</span>" );
						return null;
					}
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );
					((Ent_Static)user).visible_message( "" + user + " connects " + this + ".", "<span class='notice'>You fasten " + this + " to the port.</span>", "<span class='italics'>You hear a ratchet.</span>" );
					this.update_icon();
				}
			} else if ( A is Obj_Item_Device_Analyzer && this.Adjacent( user ) ) {
				this.atmosanalyzer_scan( this.air_contents, user );
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: portable_atmospherics.dm
		public override GasMixture portableConnectorReturnAir(  ) {
			return this.air_contents;
		}

		// Function from file: portable_atmospherics.dm
		public bool disconnect(  ) {
			
			if ( !Lang13.Bool( this.connected_port ) ) {
				return false;
			}
			this.anchored = 0;
			this.connected_port.connected_device = null;
			this.connected_port = null;
			return true;
		}

		// Function from file: portable_atmospherics.dm
		public bool connect( dynamic new_port = null ) {
			Pipeline connected_port_parent = null;

			
			if ( Lang13.Bool( this.connected_port ) || !Lang13.Bool( new_port ) || new_port.connected_device != null ) {
				return false;
			}

			if ( new_port.loc != this.loc ) {
				return false;
			}
			this.connected_port = new_port;
			this.connected_port.connected_device = this;
			connected_port_parent = this.connected_port.parents[1];
			connected_port_parent.reconcile_air();
			this.anchored = 1;
			return true;
		}

		// Function from file: portable_atmospherics.dm
		public override GasMixture return_air(  ) {
			return this.air_contents;
		}

		// Function from file: portable_atmospherics.dm
		public override int? process_atmos(  ) {
			
			if ( !Lang13.Bool( this.connected_port ) ) {
				this.air_contents.react();
			} else {
				this.update_icon();
			}
			return null;
		}

		// Function from file: portable_atmospherics.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSair.atmos_machinery.Remove( this );
			GlobalFuncs.qdel( this.air_contents );
			this.air_contents = null;
			return base.Destroy();
		}

	}

}