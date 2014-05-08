function ShowReelAppViewModel() {
	var self = this;
    
	// Private
    function addVideoClip(id) {
    	var clip = new VideoClipViewModel();

        clip.id(id);
    	clip.name(self.clipName());
    	clip.description(self.clipDescription());
    	clip.videoStandard(self.showReelStandard());
    	clip.videoDefinition(self.showReelDefinition());
    	clip.startTimeCode(self.clipStartTime());
    	clip.endTimeCode(self.clipEndTime());

        self.videoClips.push(clip);
    }
    
    function updateShowReelViewModel(id) {
        self.showReel().name(self.showReelName());
        self.showReel().videoDefinition(self.showReelDefinition());
        self.showReel().videoStandard(self.showReelStandard());
        self.showReel().id(id);
    }
    
    function updateDropDowns()
    {
        self.videoDefinitions.removeAll();
        self.videoDefinitions.push(self.showReel().videoDefinition());
        self.videoStandards.removeAll();
        self.videoStandards.push(self.showReel().videoStandard());
    }

    self.showReelName = ko.observable();
    self.showReelDefinition = ko.observable();
    self.showReelStandard = ko.observable();
	self.clipName = ko.observable();
	self.clipDescription = ko.observable();
	self.clipStartTime = ko.observable();
	self.clipEndTime = ko.observable();

	self.videoClips = ko.observableArray();
	self.showReel = ko.observable(new ShowReelViewModel());
	self.totalDuration = ko.observable();
	self.videoDefinitions = ko.observableArray(['HD', 'SD']);
    self.videoStandards = ko.observableArray(['PAL', 'NTSC']);

    self.videoClipRemoveError = ko.observable();
    self.createReelError = ko.observable();
    self.videoClipAddError = ko.observable();

    /**
    Function. Create show reel.
    */
	self.createShowReel = function () {
		var data = {
		    name: self.showReelName(),
		    definition: self.showReelDefinition(),
		    standard: self.showReelStandard()
		};

	    self.createReelError(null);

		$.post("/api/showreel", data)
            .done(function (response) {
                updateShowReelViewModel(response);
                updateDropDowns();
                
                $('.js-create-reel-form').slideUp('slow');
            })
            .fail(function (error) {
                self.createReelError("I'm sorry the show reel could not be created.");
            	console.log("Error: " + error.responseText);
            });
	};

    /**
    Function. Create video clip.
    */
	self.CreateVideoClip = function () {
		self.videoClipAddError();

		var data = {
			name: self.clipName(),
			description: self.clipDescription(),
			videoStandard: self.showReelStandard(),
			videoDefinition: self.showReelDefinition(),
			startTimeCode: self.clipStartTime(),
			endTimeCode: self.clipEndTime()
		};

	    $.post("/api/showreel/clip", data)
	        .done(function(response) {
	            addVideoClip(response);
	        })
	        .fail(function() {
	            self.videoClipAddError("Error: " + error.responseText);
	        });
	};

    /**
    Function. Remove video clip
    */
	self.removeVideoClip = function (clip) {
		self.videoClipRemoveError();
	    
		$.ajax({
			url: '/api/showreel/clip',
			type: 'DELETE',
			data: {id: clip.id}
		}).done(function() {
			self.videoClips.remove(clip);
		}).fail(function(error) {
			self.videoClipRemoveError("Error: " + error.responseText);
		});
	};
}

var app = new ShowReelAppViewModel();