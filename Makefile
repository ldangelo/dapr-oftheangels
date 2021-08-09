APPS		?= domain userservice projector

all: subsystem


subsystem:
	$(MAKE) -C Domain
	$(MAKE) -C userservice
	$(MAKE) -C projector

deploy:
	kubectl
