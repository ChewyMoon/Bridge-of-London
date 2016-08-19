function class( className )
	_ENV[className] = 
	{
		__ctr = function( self, ... )
			local instance = {}
			local instance_metatable =
			{
				self = {},
				__index = _ENV[className],
				__call = nil
			}
			setmetatable(instance, instance_metatable)
            instance:__init(...)
            return instance
		end
	}

	local class_metatable = 
	{
		__call = _ENV[className].__ctr
	}
	setmetatable(_ENV[className],  class_metatable)
end