-- title:  My first platformer
-- author: Kevin Saanen
-- desc:   platformer prototype
-- script: lua

function init()
	solids={
		[32]=true, -- sprite #XXX will be solid
		[33]=true,
		[48]=true,
		[49]=true
	}

	actor={}
	actor.x=20
	actor.y=20
	actor.velocityX=0
	actor.velocityY=0
	actor.sprite=256
	actor.scale=1
	actor.flip=0
	
	camera={}
	camera.x=0
	camera.y=0
	camera.moveX=0
	camera.moveY=0
	
	tile={}
	tile.w=16
	tile.h=16
end

init()

movecounter=0
function move()
	movecounter=movecounter+1
	-- animate sprite
	actor.moving=true
	if (movecounter==6) then
		actor.sprite=actor.sprite+2
		movecounter=0
	end
	
	if(actor.sprite>262) then
		actor.sprite=256
	end
end

function solid(x,y)
	return solids[mget((x)//8,(y)//8)]
end

function TIC()
	actor.moving=false

	if btn(2) then
		actor.velocityX=-1
		actor.flip=1
		camera.moveX=-1
		move()
	elseif btn(3) then
		actor.velocityX=1
		actor.flip=0
		camera.moveX=1
		move()
	else
		actor.velocityX=0
		camera.moveX=0
	end
	
	cls(13)
	
	-- init level
	map(
		0, -- x
		0, -- y
		30, -- w
		17, -- h
		0, -- sx
		0, -- sy
		0, -- colorkey
		1, -- scale
		nil) -- remap
	
	-- horizontal movement
	if solid(actor.x+actor.velocityX,actor.y+actor.velocityY) or solid(actor.x+14+actor.velocityX,actor.y+actor.velocityY) or solid(actor.x+actor.velocityX,actor.y+14+actor.velocityY) or solid(actor.x+14+actor.velocityX,actor.y+14+actor.velocityY) then
 	actor.velocityX=0
		camera.moveX=0
	end
	
	-- vertical movement
	if solid(actor.x,actor.y+16+actor.velocityY) or solid(actor.x+14,actor.y+16+actor.velocityY) then
 	actor.velocityY=0
		camera.moveY=0
 else
  actor.velocityY=actor.velocityY+0.2
		camera.moveY=camera.moveY+0.2
 end
	
	-- jump
	if actor.velocityY==0 and btnp(4) then
		actor.velocityY=-2.5
		camera.moveY=-2.5
	end
	
	actor.x=actor.x+actor.velocityX
	actor.y=actor.y+actor.velocityY
	
	camera.x=camera.x+camera.moveX
	camera.y=camera.y+camera.moveY
	
	spr(
		actor.sprite,
		actor.x,
		actor.y,
		0, -- colorkey 0 is black/transparent
		actor.scale,
		actor.flip,
		0, -- rotate,
		2, -- width
		2) -- height
	
end
