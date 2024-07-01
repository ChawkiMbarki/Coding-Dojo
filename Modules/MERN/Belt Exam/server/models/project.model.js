const mongoose = require('mongoose');

const projectSchema = new mongoose.Schema({
  name: {
    type: String,
    required: [true, "Name is required"],
    minlength: [3, "Name Must be must be 3 characters or longer"]
  },
  date: {
    type: Date,
    required: [true, "Date is required"]
  },
  status: {
    type: String,
    required: [true, "Status is required"]
  }
}, { timestamps: true });

const Project = mongoose.model('Project', projectSchema);

module.exports = Project;