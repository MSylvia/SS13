// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RadioFrequency : Game_Data {

		public dynamic frequency = null;
		public ByTable devices = new ByTable();

		// Function from file: communications.dm
		public void remove_listener( Obj device = null ) {
			dynamic filter = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.devices )) {
				filter = _a;
				
				this._internal_remove_listener( device, filter );
			}
			return;
		}

		// Function from file: communications.dm
		[VerbInfo( name: "remove listener" )]
		[VerbArg( 1, InputType.Obj )]
		public void _internal_remove_listener( Obj device = null, dynamic filter = null ) {
			ByTable devices_at_filter = null;

			devices_at_filter = this.devices[filter];

			if ( devices_at_filter != null && devices_at_filter.len != 0 && devices_at_filter.Find( device ) != 0 ) {
				devices_at_filter.Remove( device );

				if ( devices_at_filter.len <= 0 ) {
					this.devices.Remove( filter );
				}
			}
			return;
		}

		// Function from file: communications.dm
		public void add_listener( Obj device = null, string filter = null ) {
			ByTable devices_at_filter = null;

			
			if ( !Lang13.Bool( filter ) ) {
				filter = "_default";
			}
			devices_at_filter = this.devices[filter];

			if ( devices_at_filter == null ) {
				devices_at_filter = new ByTable();
				this.devices[filter] = devices_at_filter;
			}
			devices_at_filter.Add( device );
			return;
		}

		// Function from file: communications.dm
		public bool post_signal( Obj source = null, Game_Data signal = null, string filter = null, int? range = null ) {
			dynamic start_point = null;
			Obj device = null;
			dynamic end_point = null;
			Obj device2 = null;
			dynamic end_point2 = null;
			dynamic next_filter = null;
			Obj device3 = null;
			dynamic end_point3 = null;

			
			if ( Lang13.Bool( range ) ) {
				start_point = GlobalFuncs.get_turf( source );

				if ( !Lang13.Bool( start_point ) ) {
					GlobalFuncs.returnToPool( signal );
					return false;
				}
			}

			if ( Lang13.Bool( filter ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.devices[filter], typeof(Obj) )) {
					device = _a;
					

					if ( device == source ) {
						continue;
					}

					if ( Lang13.Bool( range ) ) {
						end_point = GlobalFuncs.get_turf( device );

						if ( !Lang13.Bool( end_point ) ) {
							continue;
						}

						if ( start_point.z != end_point.z || Map13.GetDistance( start_point, end_point ) > ( range ??0) ) {
							continue;
						}
					}
					device.receive_signal( signal, true, this.frequency );
				}

				foreach (dynamic _b in Lang13.Enumerate( this.devices["_default"], typeof(Obj) )) {
					device2 = _b;
					

					if ( device2 == source ) {
						continue;
					}

					if ( Lang13.Bool( range ) ) {
						end_point2 = GlobalFuncs.get_turf( device2 );

						if ( !Lang13.Bool( end_point2 ) ) {
							continue;
						}

						if ( start_point.z != end_point2.z || Map13.GetDistance( start_point, end_point2 ) > ( range ??0) ) {
							continue;
						}
					}
					device2.receive_signal( signal, true, this.frequency );
				}
			} else {
				
				foreach (dynamic _d in Lang13.Enumerate( this.devices )) {
					next_filter = _d;
					

					foreach (dynamic _c in Lang13.Enumerate( this.devices[next_filter], typeof(Obj) )) {
						device3 = _c;
						

						if ( device3 == source ) {
							continue;
						}

						if ( Lang13.Bool( range ) ) {
							end_point3 = GlobalFuncs.get_turf( device3 );

							if ( !Lang13.Bool( end_point3 ) ) {
								continue;
							}

							if ( start_point.z != end_point3.z || Map13.GetDistance( start_point, end_point3 ) > ( range ??0) ) {
								continue;
							}
						}
						device3.receive_signal( signal, true, this.frequency );
					}
				}
			}
			GlobalFuncs.returnToPool( signal );
			return false;
		}

	}

}