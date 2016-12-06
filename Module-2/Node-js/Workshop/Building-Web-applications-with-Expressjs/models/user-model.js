/* globals module require */

"use strict";

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const UserSchema = new mongoose.Schema({
	username: {
		type: String,
		required: true
	},
	displayName: {
		type: String,
		required: true
	},
	image: {
		type: String,
		required: true
	}
});

let User;
UserSchema.statics.getUser = (user) => {
	return new User({
		username: user.username,
		displayName: user.displayName,
		image: user.image
	});
};
mongoose.model("User", UserSchema);
User = mongoose.model("User");
module.exports = mongoose.model("User");