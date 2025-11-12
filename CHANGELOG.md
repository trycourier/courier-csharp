# Changelog

## 1.1.0 (2025-11-12)

Full Changelog: [v1.0.0...v1.1.0](https://github.com/trycourier/courier-csharp/compare/v1.0.0...v1.1.0)

### Features

* NPM enabled ([db84330](https://github.com/trycourier/courier-csharp/commit/db84330198fff3d431e4850397d113432b522048))

## 1.0.0 (2025-11-12)

Full Changelog: [v1.0.0-alpha2...v1.0.0](https://github.com/trycourier/courier-csharp/compare/v1.0.0-alpha2...v1.0.0)

### ⚠ BREAKING CHANGES

* **client:** flatten service namespaces
* **client:** interpret null as omitted in some properties
* **client:** make models immutable

### Features

* Attempt kick off again ([cfb2dbe](https://github.com/trycourier/courier-csharp/commit/cfb2dbe8d349a33d850e8a41801c34858bfb0749))
* **client:** add cancellation token support ([4a71c3e](https://github.com/trycourier/courier-csharp/commit/4a71c3e8e32df9641333d420044c2e35940debea))
* **client:** add response validation option ([3e9fae2](https://github.com/trycourier/courier-csharp/commit/3e9fae221cf807c8196e6154634ea10c4db7ae1b))
* **client:** add retries support ([ba8dc40](https://github.com/trycourier/courier-csharp/commit/ba8dc402d27c8c49fc2fb091df1d44d83e5df31b))
* **client:** add some implicit operators ([8c93861](https://github.com/trycourier/courier-csharp/commit/8c938619cf7f3b4203e82a05a5f7ff85f29adcf1))
* **client:** add support for option modification ([fdaacfa](https://github.com/trycourier/courier-csharp/commit/fdaacfa472b5fd83e7b1a3725fabf6b81bc4d8a5))
* **client:** make models immutable ([1a4515b](https://github.com/trycourier/courier-csharp/commit/1a4515b65f1b59a3bc05bfa662e04b78719d9660))
* **client:** send `User-Agent` header ([e03b54b](https://github.com/trycourier/courier-csharp/commit/e03b54bf398bfb8eb59245eb0253140b88f60da3))
* **client:** send `X-Stainless-Arch` header ([355ce4d](https://github.com/trycourier/courier-csharp/commit/355ce4df5a9c23ea908a887e9de0cfcf12d9c47e))
* **client:** send `X-Stainless-Lang` and `X-Stainless-OS` headers ([ec7b4b8](https://github.com/trycourier/courier-csharp/commit/ec7b4b8404519c719d16df319b3e17e671448536))
* **client:** send `X-Stainless-Package-Version` headers ([a4171fd](https://github.com/trycourier/courier-csharp/commit/a4171fd9de7b6329d96c693f5211a409810ad88c))
* **client:** send `X-Stainless-Runtime` and `X-Stainless-Runtime-Version` ([263cbf1](https://github.com/trycourier/courier-csharp/commit/263cbf1d6248ea1c081f22819243ded8660b3c7f))
* **client:** send `X-Stainless-Timeout` header ([c0c691a](https://github.com/trycourier/courier-csharp/commit/c0c691abc95312f3d6fb628b1934da3b698773ca))
* **client:** support request timeout ([7d68644](https://github.com/trycourier/courier-csharp/commit/7d68644246482254f3a0aee0f77808640a4effa8))
* Organization update ([b82d346](https://github.com/trycourier/courier-csharp/commit/b82d346403253e6f0f1ae5107a58a6333f3c538b))
* Spec Comment Change ([eaf3aab](https://github.com/trycourier/courier-csharp/commit/eaf3aabfecc31c2054d3e1e437311f1800277645))
* Token Prop Description Change ([7110be1](https://github.com/trycourier/courier-csharp/commit/7110be1a27a6cca7167eb7292a9480d53e6a8fad))


### Bug Fixes

* Better Python Samples + Updates to naming ([324f06a](https://github.com/trycourier/courier-csharp/commit/324f06ad204a0b4ba30651df5330e992ce6300f2))
* **client:** interpret null as omitted in some properties ([025593e](https://github.com/trycourier/courier-csharp/commit/025593e5aa6aed69408f1af780a7eb39530c42dc))


### Performance Improvements

* **client:** optimize header creation ([8bcbba2](https://github.com/trycourier/courier-csharp/commit/8bcbba2466755dc38cf27ed559847bf7d6c331e6))


### Chores

* **client:** simplify field validations ([3e9fae2](https://github.com/trycourier/courier-csharp/commit/3e9fae221cf807c8196e6154634ea10c4db7ae1b))
* **internal:** add prism log file to gitignore ([6215c41](https://github.com/trycourier/courier-csharp/commit/6215c4157c61129c00494b8243d49195c57b8ca2))
* **internal:** codegen related update ([370e046](https://github.com/trycourier/courier-csharp/commit/370e046e7f4398ac1c07ab17b0bc3c6f0e84ec45))
* **internal:** delete empty test files ([6feb8cd](https://github.com/trycourier/courier-csharp/commit/6feb8cd995e11fb347f3779206ed504c6854b223))
* **internal:** extract `ClientOptions` struct ([ed8a90d](https://github.com/trycourier/courier-csharp/commit/ed8a90d5e1cf1137cde837181830167a2820eea2))
* **internal:** full qualify some references ([f2b2bff](https://github.com/trycourier/courier-csharp/commit/f2b2bff6b34e0ca36ffc09759636ba0311246d50))
* **internal:** improve devcontainer ([e696694](https://github.com/trycourier/courier-csharp/commit/e69669492371d1345b21a023c115f08941558340))
* **internal:** minor improvements to csproj and gitignore ([4c26559](https://github.com/trycourier/courier-csharp/commit/4c26559873809df61b43d0ad48ee55bcbdab3b12))
* **internal:** reduce import qualification ([044c3f8](https://github.com/trycourier/courier-csharp/commit/044c3f877e50bbc53c01465ace3f78d5bdecc27a))
* update SDK settings ([0232166](https://github.com/trycourier/courier-csharp/commit/02321665974d4fc60dd59693ace28142e21243c5))


### Documentation

* **client:** document `WithOptions` ([270f86a](https://github.com/trycourier/courier-csharp/commit/270f86ae473c27464521f814546a9c7b72b8ea46))
* **client:** document max retries ([76b8e6d](https://github.com/trycourier/courier-csharp/commit/76b8e6dba5985ebbbc6dc0d8df6952f68e731bb3))
* **client:** document response validation ([f48fca0](https://github.com/trycourier/courier-csharp/commit/f48fca037ae6894f0fd76999899216424975373e))
* **client:** document timeout option ([472ff48](https://github.com/trycourier/courier-csharp/commit/472ff48b1a9c5cc064b81bb251b6fab1151ebcae))
* **client:** improve snippet formatting ([dc01c18](https://github.com/trycourier/courier-csharp/commit/dc01c180926fa917a3f0c134b689a7219ef5b086))
* **client:** separate comment content into paragraphs ([cd741ed](https://github.com/trycourier/courier-csharp/commit/cd741ed030a9d69d526da947e8a9c08bf958aed1))


### Refactors

* **client:** flatten service namespaces ([b92687e](https://github.com/trycourier/courier-csharp/commit/b92687eb7b0a18fa3e0e43ccc81a2791d991af1c))
* **client:** pass around `ClientOptions` instead of client ([ce05c19](https://github.com/trycourier/courier-csharp/commit/ce05c19c18e94605ebfb9bf3a2ce50093eb82649))

## 1.0.0-alpha2 (2025-10-31)

Full Changelog: [v1.0.0-alpha1...v1.0.0-alpha2](https://github.com/trycourier/courier-csharp/compare/v1.0.0-alpha1...v1.0.0-alpha2)

### Features

* Comment adjustment to kick of build ([6e9e20c](https://github.com/trycourier/courier-csharp/commit/6e9e20c6a5b189684233a90acf5fd20f6b66f901))


### Bug Fixes

* Comment to kick off build ([158b124](https://github.com/trycourier/courier-csharp/commit/158b12492b8e17644ac3868980b6ca74e547d10b))
* **internal:** minor bug fixes on model instantiation and union validation ([c064475](https://github.com/trycourier/courier-csharp/commit/c064475ae553d991dfcb87510e53623fdc278461))

## 1.0.0-alpha1 (2025-10-18)

Full Changelog: [v1.0.0-alpha0...v1.0.0-alpha1](https://github.com/trycourier/courier-csharp/compare/v1.0.0-alpha0...v1.0.0-alpha1)

### Features

* More PHP and attempted node automerge ([bbdaa77](https://github.com/trycourier/courier-csharp/commit/bbdaa77b47d46b8835c5de3e13ede2dc033ef0ab))


### Bug Fixes

* Dep Warning ([09bb055](https://github.com/trycourier/courier-csharp/commit/09bb05576a07ada91cd00acc87c334ee9085c642))
* Updated paths for each model and go example updates ([8324cfd](https://github.com/trycourier/courier-csharp/commit/8324cfde1ecd60e36fdff7bd040c34b3661e7579))

## 1.0.0-alpha0 (2025-10-14)

Full Changelog: [v0.1.0...v1.0.0-alpha0](https://github.com/trycourier/courier-csharp/compare/v0.1.0...v1.0.0-alpha0)

### Features

* Changes to spec, examples and scripts ([6458d15](https://github.com/trycourier/courier-csharp/commit/6458d1581373364ba37c6fa5e8f08123b396e4be))

## 0.1.0 (2025-10-14)

Full Changelog: [v0.0.1...v0.1.0](https://github.com/trycourier/courier-csharp/compare/v0.0.1...v0.1.0)

### Features

* **api:** manual updates ([150c602](https://github.com/trycourier/courier-csharp/commit/150c602a311b6e107e8d4db0bf1e7727e44382fe))
* **api:** manual updates ([0f54d69](https://github.com/trycourier/courier-csharp/commit/0f54d696e80505a8c0952602ef94d1b6860c87bc))
* **api:** manual updates ([6046287](https://github.com/trycourier/courier-csharp/commit/604628763283339bf2dea199cf2a9cd6000ba3e8))
* **api:** manual updates ([3a0716d](https://github.com/trycourier/courier-csharp/commit/3a0716d1680745cfdf5e3914b3f30a73d89d5541))
* **api:** manual updates ([305c2a8](https://github.com/trycourier/courier-csharp/commit/305c2a862f2c469304e01d5b90cb5b6b19008d0c))
* **api:** manual updates ([716af85](https://github.com/trycourier/courier-csharp/commit/716af85b56c054e603dee4a296dfb9f2d31063de))
* **api:** manual updates ([70c393d](https://github.com/trycourier/courier-csharp/commit/70c393d4f4b3b4193bacdb5b8240be509acbd871))
* **api:** manual updates ([0b00456](https://github.com/trycourier/courier-csharp/commit/0b0045622ce6ca027a859b6011c4c16492a4bdd3))
* **api:** manual updates ([ba68884](https://github.com/trycourier/courier-csharp/commit/ba688847d5f3c69032034c7c437a2c973a5d1d62))
* **api:** manual updates ([0aef606](https://github.com/trycourier/courier-csharp/commit/0aef60638a2b129a54699a85ecdc5baad9bc80ba))
* **api:** manual updates ([610c174](https://github.com/trycourier/courier-csharp/commit/610c174d96d9079a4e7a6277f998b1df54efa1e2))
* **api:** manual updates ([f33646a](https://github.com/trycourier/courier-csharp/commit/f33646ad20ed860a83a9a143c552d0c1c1c6aab4))
* **api:** manual updates ([9360a1e](https://github.com/trycourier/courier-csharp/commit/9360a1e31e19a818bcdc39aa34d9e7250538abf5))
* **api:** manual updates ([eba702d](https://github.com/trycourier/courier-csharp/commit/eba702d6f4012affd5db600fb949ea87e0d1a555))
* **api:** manual updates ([eb153f1](https://github.com/trycourier/courier-csharp/commit/eb153f1cf51394246436ba4e7d3933c226550eb8))
* **api:** manual updates ([f3af685](https://github.com/trycourier/courier-csharp/commit/f3af685e18705bb3b678c078572abdaf94cee838))
* **api:** manual updates ([4c0dce4](https://github.com/trycourier/courier-csharp/commit/4c0dce48f115a1fbbd1336c0a037b52d3256b695))
* **api:** manual updates ([c8cd2de](https://github.com/trycourier/courier-csharp/commit/c8cd2de31fa3c47636cc4443d0548a08ed26a264))
* **api:** manual updates ([285843a](https://github.com/trycourier/courier-csharp/commit/285843aabdbd692b7c49497832b9647f81117c0e))
* **api:** manual updates ([22b6664](https://github.com/trycourier/courier-csharp/commit/22b6664af1b901d36a21be9ea5f07ef616be014a))
* **api:** manual updates ([4ad6b6b](https://github.com/trycourier/courier-csharp/commit/4ad6b6b7b0fa115dac3ed546e3db122ee1bc677d))
* **api:** manual updates ([b91cb3d](https://github.com/trycourier/courier-csharp/commit/b91cb3d53914f205f649af1f6c180eab996a7e70))
* **api:** manual updates ([c177c43](https://github.com/trycourier/courier-csharp/commit/c177c436120795ef65a4e99c51d276728e984763))
* **api:** manual updates ([3db70da](https://github.com/trycourier/courier-csharp/commit/3db70dadbcbed8fe12972a6ce110dd262381507a))
* **api:** manual updates ([d382d5e](https://github.com/trycourier/courier-csharp/commit/d382d5e731725f3794563e3f7d5fd3bbbe08236f))
* **api:** manual updates ([23dda11](https://github.com/trycourier/courier-csharp/commit/23dda11e3d100044c6ef3f82d3fae6bef32bfad1))
* **api:** manual updates ([770ff34](https://github.com/trycourier/courier-csharp/commit/770ff34472e014d851834c9ae72eae4c15191fe9))
* **api:** manual updates ([d08651e](https://github.com/trycourier/courier-csharp/commit/d08651e0cbea0bde2daaca033e07d8c157b88ef5))
* **api:** manual updates ([df7481e](https://github.com/trycourier/courier-csharp/commit/df7481e8b56f4cdb8e0ed0b68066c53736ad1eb0))
* **api:** manual updates ([d08289a](https://github.com/trycourier/courier-csharp/commit/d08289a5a50169ba89a6ee399cd22647726bcb1e))
* **client:** refactor unions ([c0de93e](https://github.com/trycourier/courier-csharp/commit/c0de93e4bea470ea6a1e4735764c6e4d8737fc83))
* Examples and ref polish ([0049bd2](https://github.com/trycourier/courier-csharp/commit/0049bd2ba39ce59f0cdec2d082429ba164b01176))
* **internal:** add dev container ([af90ed9](https://github.com/trycourier/courier-csharp/commit/af90ed99cd28ff6fa7ec543460c232303bddb931))
* Model sync ([3ae0cc0](https://github.com/trycourier/courier-csharp/commit/3ae0cc07bb3c9ed658de6a5b79b663411797e3c3))
* Polish and Kick of Java Kit Gen ([af84106](https://github.com/trycourier/courier-csharp/commit/af84106381b0d739cca10981da57d3f9793245d4))
* Template Id ([dcc3ef6](https://github.com/trycourier/courier-csharp/commit/dcc3ef67a4ee5e0bf0c814038cfeb870a010dca8))
* Test Github Action ([9df50a9](https://github.com/trycourier/courier-csharp/commit/9df50a94c7aeec8caf9c4c104fd146bbf54716f4))


### Chores

* **internal:** restructure some imports ([4d553f5](https://github.com/trycourier/courier-csharp/commit/4d553f595f178337856256e910ebd703c0a845ab))
* sync repo ([0dacae4](https://github.com/trycourier/courier-csharp/commit/0dacae4b53bfed438732c9b2eb5dd98e2d72c395))
* update SDK settings ([4e24bdb](https://github.com/trycourier/courier-csharp/commit/4e24bdb64b47ee721c04a100e9ad3f9126665880))
* update SDK settings ([c390781](https://github.com/trycourier/courier-csharp/commit/c390781282cf54a9f6e99b1ff0a5d093b2ca2751))
