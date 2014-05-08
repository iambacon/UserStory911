function VideoClipViewModel() {
    var self = this;

    self.id = ko.observable();
    self.showReelId = ko.observable();
    self.name = ko.observable();
    self.description = ko.observable();
    self.videoStandard = ko.observable();
    self.videoDefinition = ko.observable();
    self.startTimeCode = ko.observable();
    self.endTimeCode = ko.observable();
}