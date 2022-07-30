using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerConfigurator.Api.Motherboard
{
    [ApiController]
    [Route("/[controller]/[action]/")]
    public class MotherboardController : ControllerBase
    {
        private readonly CCContext _context;

        public MotherboardController(CCContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DTO.Create createMotherboard)
        {
            IReadOnlyList<string> errors = createMotherboard.Validate();

            if (errors.Any()) return BadRequest(errors);

            bool manufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == createMotherboard.ManufacturerUUID);

            if (manufacturerExists == false) return NotFound();

            if (await Part.Part.Duplicate(_context, createMotherboard)) return Conflict();

            bool cpuSocketExists = await _context.CPUSocket.AnyAsync(x =>
                x.UUID == createMotherboard.CPUSocketUUID
            );

            if (cpuSocketExists == false) return NotFound();

            bool motherboardFormFactorExists = await _context.MotherboardFormFactor.AnyAsync(x =>
                x.UUID == createMotherboard.MotherboardFormFactorUUID
            );

            if (motherboardFormFactorExists == false) return NotFound();

            bool motherboardChipsetExists = await _context.MotherboardChipset.AnyAsync(x =>
                x.UUID == createMotherboard.MotherboardChipsetUUID
            );

            if (motherboardChipsetExists == false) return NotFound();

            foreach (MotherboardDisplayConnector.DTO.Create createMotherboardDisplayConnector in createMotherboard.DisplayConnectors)
            {
                bool displayConnectorExists = await _context.DisplayConnector.AnyAsync(displayConnector =>
                    displayConnector.UUID == createMotherboardDisplayConnector.DisplayConnectorUUID
                );

                if (displayConnectorExists == false) return NotFound();
            }

            foreach (MotherboardEthernetPort.DTO.Create createMotherboardEthernetPort in createMotherboard.EthernetPorts)
            {
                bool ethernetPortExists = await _context.EthernetPort.AnyAsync(ethernetPort =>
                    ethernetPort.UUID == createMotherboardEthernetPort.EthernetPortUUID
                );

                if (ethernetPortExists == false) return NotFound();
            }

            foreach (MotherboardFanHeader.DTO.Create createMotherboardFanHeader in createMotherboard.FanHeaders)
            {
                bool fanHeaderExists = await _context.FanHeader.AnyAsync(fanHeader =>
                    fanHeader.UUID == createMotherboardFanHeader.FanHeaderUUID
                );

                if (fanHeaderExists == false) return NotFound();
            }

            foreach (MotherboardNVMEConnector.DTO.Create createMotherboardNVMEConnector in createMotherboard.NVMEConnectors)
            {

                bool pcieGenerationExists = await _context.PCIEGeneration.AnyAsync(pcieGeneration =>
                    pcieGeneration.UUID == createMotherboardNVMEConnector.PCIEGenerationUUID
                );

                if (pcieGenerationExists == false) return NotFound();

                bool nvmeInterfaceExists = await _context.NVMEInterface.AnyAsync(nvmeInterface =>
                    nvmeInterface.UUID == createMotherboardNVMEConnector.NVMEInterfaceUUID
                );

                if (nvmeInterfaceExists == false) return NotFound();

                bool nvmeFormFactorExists = await _context.NVMEFormFactor.AnyAsync(nvmeFormFactor =>
                    nvmeFormFactor.UUID == createMotherboardNVMEConnector.NVMEFormFactorUUID
                );

                if (nvmeFormFactorExists == false) return NotFound();
            }

            foreach (MotherboardPCIEConnector.DTO.Create createMotherboardPCIEConnector in createMotherboard.PCIEConnectors)
            {
                bool pcieConnectorExists = await _context.PCIEConnector.AnyAsync(pcieConnector =>
                    pcieConnector.UUID == createMotherboardPCIEConnector.PCIEConnectorUUID
                );

                if (pcieConnectorExists == false) return NotFound();
            }

            foreach (MotherboardRAMSocket.DTO.Create createMotherboardRAMSocket in createMotherboard.RAMSockets)
            {
                bool ramSocketExists = await _context.RAMSocket.AnyAsync(ramSocket =>
                    ramSocket.UUID == createMotherboardRAMSocket.RAMSocketUUID
                );

                if (ramSocketExists == false) return NotFound();
            }

            foreach (MotherboardRAMSpeed.DTO.Create createMotherboardRAMSpeed in createMotherboard.RAMSpeeds)
            {
                bool ramSpeedExists = await _context.RAMSpeed.AnyAsync(ramSpeed =>
                    ramSpeed.UUID == createMotherboardRAMSpeed.RAMSpeedUUID
                );

                if (ramSpeedExists == false) return NotFound();
            }

            foreach (MotherboardSATAConnector.DTO.Create createMotherboardSATAConnector in createMotherboard.SATAConnectors)
            {
                bool sataConnectorExists = await _context.SATAGeneration.AnyAsync(sataConnector =>
                    sataConnector.UUID == createMotherboardSATAConnector.SATAGenerationUUID
                );

                if (sataConnectorExists == false) return NotFound();
            }

            foreach (MotherboardUSBPort.DTO.Create createMotherboardUSBPort in createMotherboard.USBPorts)
            {
                bool usbPortExists = await _context.USBPort.AnyAsync(usbPort =>
                    usbPort.UUID == createMotherboardUSBPort.USBPortUUID
                );

                if (usbPortExists == false) return NotFound();
            }

            Motherboard motherboard = new Motherboard(createMotherboard);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DTO.Details>>> GetAll()
        {
            List<DTO.Details> allMotherboardDetails = new();

            IAsyncEnumerable<Motherboard> query = _context.Motherboard
                .Include(x => x.CPUSocket)
                .Include(x => x.MotherboardFormFactor)
                .Include(x => x.MotherboardChipset)
                .Include(x => x.DisplayConnectors)
                .Include(x => x.EthernetPorts)
                .Include(x => x.FanHeaders)
                .Include(x => x.NVMEConnectors)
                .Include(x => x.PCIEConnectors)
                .Include(x => x.RAMSockets)
                .Include(x => x.SupportedRAMSpeeds)
                .Include(x => x.SATAConnectors)
                .Include(x => x.USBPorts)
                .Include(x => x.Part)
                .ThenInclude(x => x.Manufacturer)
                .AsAsyncEnumerable();

            await foreach (Motherboard motherboard in query)
            {
                DTO.Details motherboardDetails = new(motherboard);

                allMotherboardDetails.Add(motherboardDetails);
            }

            return Ok(allMotherboardDetails);
        }

        [HttpGet]
        public async Task<ActionResult<DTO.Details>> GetByUUID(Guid motherboardUUID)
        {
            Motherboard? motherboard = await _context.Motherboard.FirstOrDefaultAsync(x => x.UUID == motherboardUUID);

            if (motherboard == null) return NotFound();

            DTO.Details motherboardDetails = new DTO.Details(motherboard);

            return Ok(motherboardDetails);
        }

        [HttpPatch]
        public async Task<ActionResult> Edit(DTO.Edit editMotherboard)
        {
            IReadOnlyList<string> errors = editMotherboard.Validate();

            if (errors.Any()) return BadRequest(errors);

            Motherboard? motherboard = await _context.Motherboard.FirstOrDefaultAsync(x => x.UUID == editMotherboard.UUID);

            if (motherboard == null) return NotFound();

            if (motherboard.ManufacturerUUID != editMotherboard.ManufacturerUUID)
            {
                bool newManufacturerExists = await _context.Manufacturer.AnyAsync(x => x.UUID == editMotherboard.ManufacturerUUID);

                if (newManufacturerExists == false) return NotFound();

                if (motherboard.Model.ToLower() != editMotherboard.Model.ToLower())
                {
                    bool duplicate = await Part.Part.Duplicate(_context, editMotherboard);

                    if (duplicate) return Conflict();
                }
            }

            if (motherboard.CPUSocketUUID != editMotherboard.CPUSocketUUID)
            {
                bool newMotherboardCPUSocketExists = await _context.CPUSocket.AnyAsync(x =>
                    x.UUID == editMotherboard.CPUSocketUUID
                );

                if (newMotherboardCPUSocketExists == false) return NotFound();
            }

            if (motherboard.MotherboardFormFactorUUID != editMotherboard.MotherboardFormFactorUUID)
            {
                bool newMotherboardFormFactorExists = await _context.MotherboardFormFactor.AnyAsync(x =>
                    x.UUID == editMotherboard.MotherboardFormFactorUUID
                );

                if (newMotherboardFormFactorExists == false) return NotFound();
            }

            if (motherboard.MotherboardChipsetUUID != editMotherboard.MotherboardChipsetUUID)
            {
                bool newMotherboardChipsetExists = await _context.MotherboardChipset.AnyAsync(x =>
                    x.UUID == editMotherboard.MotherboardChipsetUUID
                );

                if (newMotherboardChipsetExists == false) return NotFound();
            }

            Motherboard.Edit(motherboard, editMotherboard);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid motherboardUUID)
        {
            Motherboard? motherboard = await _context.Motherboard.FirstOrDefaultAsync(x => x.UUID == motherboardUUID);

            if (motherboard == null) return NotFound();

            _context.Motherboard.Remove(motherboard);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
