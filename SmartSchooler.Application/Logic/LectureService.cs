﻿using Mapster;
using SmartSchooler.Application.Contract;
using SmartSchooler.Application.DTOs;
using SmartSchooler.Domain.Entities;
using SmartSchooler.Domain.Repositories;

namespace SmartSchooler.Application.Logic
{
    public class LectureService : ILectureService
    {
        private readonly IRepository _repositoryManager;

        public LectureService(IRepository repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<LectureDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var Lectures = await _repositoryManager.LectureRepository.ListAsync(cancellationToken);

            return Lectures.Adapt<IEnumerable<LectureDto>>();
        }

        public async Task<LectureDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var Lectures = await _repositoryManager.LectureRepository.GetByIdAsync(id, cancellationToken);

            return Lectures.Adapt<LectureDto>();
        }

        public async Task<LectureDto> AddAsync(LectureForCreationDto LectureForCreationDto, CancellationToken cancellationToken = default)
        {
            var Lectures = LectureForCreationDto.Adapt<Lecture>();

            _repositoryManager.LectureRepository.Add(Lectures);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Lectures.Adapt<LectureDto>();
        }
    }
}
