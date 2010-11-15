include FileTest
require 'albacore'

COMPILE_TARGET = "debug"
PROJECT_ROOT = File.dirname(__FILE__)
OUTPUT_DIR = File.join(PROJECT_ROOT, "build/bin/#{COMPILE_TARGET}/")

	desc "Create build"
	task :all => [:config, :compile]
	
	desc "Prepares the working directory for a new build"
	task :clean do
	  Dir.mkdir OUTPUT_DIR unless exists?(OUTPUT_DIR)
	end

	desc "Expand .config files for the correct environment"
	expandtemplates :config, [:env] do |tmp, args|
		args.with_defaults(:env => "local")
		tmp.expand_files( 
			"build/config/Web.config.template" => "Foundations.Web.UI/Web.config")
		tmp.data_file = "build/config/#{args.env}.settings"
	end

	desc "Create a build"
	msbuild :compile => [:clean] do |msb|
		
	  msb.properties = {:configuration => :Debug, :OutDir => OUTPUT_DIR}
	  msb.targets [:Clean, :Rebuild]
	  msb.verbosity = "minimal"
	  msb.solution = "WebFoundations.sln"
	end
	
